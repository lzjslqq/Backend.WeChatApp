using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.Extensions;
using Backend.WeChatApp.Repository.SqlServer;
using Backend.WeChatApp.Service.Common;
using Backend.WeChatApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;
using Backend.WeChatApp.Utility.Extensions;

namespace Backend.WeChatApp.Service
{
	public class MembershipService : IMembershipService
	{
		#region 字段及构造函数

		private readonly ICryptoService _cryptoService;
		private readonly ISqlRepository<User> _userRepository;
		private readonly ISqlRepository<Role> _roleRepository;
		private readonly ISqlRepository<UserInRole> _userInRoleRepository;

		public MembershipService(ICryptoService cryptoService, ISqlRepository<User> userRepository, ISqlRepository<Role> roleRepository, ISqlRepository<UserInRole> userRoleRepository)
		{
			_cryptoService = cryptoService;
			_userRepository = userRepository;
			_roleRepository = roleRepository;
			_userInRoleRepository = userRoleRepository;
		}

		#endregion 字段及构造函数

		#region 业务方法

		public ValidUserContext ValidateUser(string username, string password)
		{
			var userContext = new ValidUserContext();
			var user = _userRepository.GetSingleByUsername(username);
			if (user != null && isUserValid(user, password))
			{
				var userRoles = _userInRoleRepository.GetUserRoles(_roleRepository, user.Id);
				userContext.User = new UserWithRoles { User = user, Roles = userRoles };

				var identity = new GenericIdentity(user.Name);
				userContext.Principal = new GenericPrincipal(identity, userRoles.Select(x => x.Name).ToArray());
			}

			return userContext;
		}

		public OperationResult<UserWithRoles> CreateUser(string username, string email, string password)
		{
			return CreateUser(username, password, email, roles: null);
		}

		public OperationResult<UserWithRoles> CreateUser(string username, string email, string password, string role)
		{
			return CreateUser(username, password, email, roles: new[] { role });
		}

		public OperationResult<UserWithRoles> CreateUser(string username, string email, string password, IEnumerable<string> roles)
		{
			var existingUser = _userRepository.GetSingleByUsername(username);

			if (existingUser != null)
			{
				return new OperationResult<UserWithRoles>(false, "该用户已存在");
			}

			var passwordSalt = _cryptoService.GenerateSalt();

			var user = new User()
			{
				Name = username,
				Salt = passwordSalt,
				Email = email,
				IsLocked = false,
				HashedPassword = _cryptoService.EncryptPassword(password, passwordSalt),
				CreateTime = DateTime.Now,
				Status = 1
			};

			Guid userId = _userRepository.Insert(user);

			if (roles.IsNotEmpty())
			{
				foreach (var roleName in roles)
				{
					// 添加到用户角色表
					addUserToRole(user, roleName);
				}
			}

			return new OperationResult<UserWithRoles>(true)
			{
				Entity = GetUserWithRoles(user)
			};
		}

		public UserWithRoles UpdateUser(User user)
		{
			user.UpdateTime = DateTime.Now;
			_userRepository.Update(user);

			return GetUserWithRoles(user);
		}

		public bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			throw new NotImplementedException();
		}

		public bool AddToRole(Guid userId, string role)
		{
			throw new NotImplementedException();
		}

		public bool AddToRole(string username, string role)
		{
			throw new NotImplementedException();
		}

		public bool RemoveFromRole(string username, string role)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Role> GetRoles()
		{
			throw new NotImplementedException();
		}

		public Role GetRole(Guid key)
		{
			throw new NotImplementedException();
		}

		public Role GetRole(string name)
		{
			throw new NotImplementedException();
		}

		public UserWithRoles GetUser(Guid id)
		{
			throw new NotImplementedException();
		}

		public UserWithRoles GetUser(string name)
		{
			throw new NotImplementedException();
		}

		#endregion 业务方法

		#region 辅助方法

		private bool isUserValid(User user, string password)
		{
			if (isPasswordValid(user, password))
			{
				return !user.IsLocked;
			}

			return false;
		}

		private bool isPasswordValid(User user, string password)
		{
			return string.Equals(_cryptoService.EncryptPassword(password, user.Salt), user.HashedPassword);
		}

		private UserWithRoles GetUserWithRoles(User user)
		{
			if (user != null)
			{
				var userRoles = _userInRoleRepository.GetUserRoles(_roleRepository, user.Id);
				return new UserWithRoles()
				{
					User = user,
					Roles = userRoles
				};
			}

			return null;
		}

		private void addUserToRole(User user, string roleName)
		{
			var role = _roleRepository.GetSingleByRoleName(roleName);
			Guid roleId = role == null ? Guid.Empty : role.Id;

			if (role == null)
			{
				var newRole = new Role
				{
					Name = roleName,
					CreateTime = DateTime.Now,
					Status = 1
				};

				roleId = _roleRepository.Insert(newRole);
			}

			var userInRole = new UserInRole()
			{
				RoleId = roleId,
				UserId = user.Id,
				CreateTime = DateTime.Now,
				Status = 1
			};

			_userInRoleRepository.Insert(userInRole);
		}

		#endregion 辅助方法
	}
}