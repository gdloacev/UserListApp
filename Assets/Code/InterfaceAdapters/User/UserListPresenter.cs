using UserListApp.Utils;
using System.Collections.Generic;
using UniRx;
using UserListApp.Domain;

namespace UserListApp.InterfaceAdapters.User
{
    public class UserListPresenter
    {
        private readonly UserListViewModel _model;
        private readonly UserRequester _listRequester;
        private readonly List<UserListViewModelIns> _userList;
        internal UserListPresenter(UserListViewModel model, UserRequester requester)
        {
            _model = model;
            _listRequester = requester;
            UnityEngine.Debug.Log("Presenter");
            _listRequester.SendUserList.Subscribe<List<UserListApp.Domain.User>>(OnUserListRetrieve);
            _userList = new List<UserListViewModelIns>();
        }

        private void OnUserListRetrieve(List<UserListApp.Domain.User> users)
        {
            users.ForEach((user) => {
                UserListViewModelIns convUser = new UserListViewModelIns(user.Picture.Thumbnail, user.Name.ToString(), false);
                _userList.Add(convUser);
            });
            UnityEngine.Debug.Log("Presenter - OnUserListRetrieve");
            _model.UserList.Value = _userList;
            UnityEngine.Debug.Log(_model.UserList.Value.Count.ToString());
            _model.UserListUpdated.Execute();
        }
    }

}
