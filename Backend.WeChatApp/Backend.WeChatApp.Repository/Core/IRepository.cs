using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Repository
{
	public interface IRepository<T>
	{
		T Get(Guid id);

		bool Update(T t);

		dynamic Insert(T apply);

		bool Delete(T t);
	}
}