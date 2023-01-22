using System;
namespace MyAspNetProject.Web.Helpers
{
	public class Helper:IHelper
	{
        private bool isConfugiration;
		public Helper(bool _isConfugiration)
		{
            _isConfugiration = isConfugiration;
		}

        public string Upper(string text)
        {
            return text.ToUpper();
        }
    }
}

