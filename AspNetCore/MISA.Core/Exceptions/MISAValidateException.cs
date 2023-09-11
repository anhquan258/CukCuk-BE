using System;
namespace MISA.Core.Exceptions
{
	public class MISAValidateException : Exception
	{
        string? MsgErrorValidate = null;
        public MISAValidateException(string msg)
		{
			this.MsgErrorValidate = msg; 
		}

        public override string Message
		{
			get
			{
				return MsgErrorValidate;
			}
		}
    }
}

