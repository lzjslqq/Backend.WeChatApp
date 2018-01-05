using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.WeChatApp.Service.Common
{
	public class OperationResult
	{
		public bool IsSuccess { get; private set; }
		public string Message { get; private set; }

		public OperationResult(bool isSuccess, string message)
		{
			IsSuccess = isSuccess;
			Message = message;
		}
	}

	public class OperationResult<TEntity> : OperationResult
	{
		public OperationResult(bool isSuccess, string message)
			: base(isSuccess, message)
		{
		}

		public TEntity Entity { get; set; }
	}
}