using UserListApp.Domain;
using System.Diagnostics;
using System.Threading.Tasks;
using UniRx;
using UserListApp.InterfaceAdapters.User;

public class UserController { 
    private readonly UserListViewModel _model;
	private readonly UserRequester _userRequester;
	private readonly string _url;

	internal UserController(UserListViewModel model, UserRequester userRequester, string url)
	{
		try
		{
			_model = model;
			_model.ShowUserList.Subscribe(OnShowUserList);
			_url = url;
			_userRequester = userRequester;
		}
		catch (System.Exception ex)
		{
            UnityEngine.Debug.Log(ex.Message);
        }
	}

	private void OnShowUserList(Unit _) {
		try
		{
            UnityEngine.Debug.Log("Controller");
            _userRequester.GetUsers(_url).Start();
		}
		catch (System.Exception ex)
		{
            UnityEngine.Debug.Log(ex.Message);
        }
	}
}
