using Backend.WeChatApp.Entity;
using Backend.WeChatApp.Repository.Extensions;
using Backend.WeChatApp.Repository.Sql;
using Backend.WeChatApp.Service.Common;
using Backend.WeChatApp.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Backend.WeChatApp.Service
{
	public class MembershipService : IMembershipService
	{
		#region 字段及构造函数

		private readonly ICryptoService _cryptoService;
		private readonly ISqlRepository<User> _userRepository;
		private readonly ISqlRepository<Role> _roleRepository;
		private readonly ISqlRepository<UserRole> _userRoleRepository;

		public MembershipService(ICryptoService cryptoService, ISqlRepository<User> userRepository, ISqlRepository<Role> roleRepository, ISqlRepository<UserRole> userRoleRepository)
		{
			_cryptoService = cryptoService;
			_userRepository = userRepository;
			_roleRepository = roleRepository;
			_userRoleRepository = userRoleRepository;
		}

		#endregion 字段及构造函数

		#region 业务方法

		public ValidUserContext ValidateUser(string username, string password)
		{
			var userContext = new ValidUserContext();
			var user = _userRepository.GetSingleByUsername(username);
			if (user != null && isUserValid(user, password))
			{
			}

			return userContext;
		}

		public OperationResult<UserWithRoles> CreateUser(string username, string email, string password)
		{
			throw new NotImplementedException();
		}

		public OperationResult<UserWithRoles> CreateUser(string username, string email, string password, string role)
		{
			throw new NotImplementedException();
		}

		public OperationResult<UserWithRoles> CreateUser(string username, string email, string password, string[] roles)
		{
			throw new NotImplementedException();
		}

		public UserWithRoles UpdateUser(Entity.User user, string username, string email)
		{
			throw new NotImplementedException();
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

		public IEnumerable<Entity.Role> GetRoles()
		{
			throw new NotImplementedException();
		}

		public Entity.Role GetRole(Guid key)
		{
			throw new NotImplementedException();
		}

		public Entity.Role GetRole(string name)
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

		#endregion 辅助方法
	}
}