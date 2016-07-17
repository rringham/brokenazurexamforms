using System;
using System.Threading.Tasks;

namespace BrokenAzureForms
{
	public interface IUserService
	{
		Task<bool> LoginWithAzureAD();

		Task Logout();
	}
}