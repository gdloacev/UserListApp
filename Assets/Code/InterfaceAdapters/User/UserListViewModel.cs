using System.Collections;
using System.Collections.Generic;
using UniRx;

namespace UserListApp.InterfaceAdapters.User
{

    public class UserListViewModel
    {
        internal readonly ReactiveCommand ShowUserList;
        internal ReactiveProperty<List<UserListViewModelIns>> UserList { get; set; }
        internal readonly ReactiveCommand UserListUpdated;

        public UserListViewModel()
        {
            ShowUserList = new ReactiveCommand();
            UserList = new ReactiveProperty<List<UserListViewModelIns>>();
            UserListUpdated = new ReactiveCommand();
        }
    }
    public class UserListViewModelIns
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public bool Like { get; set; }

        public UserListViewModelIns(string picture, string name, bool like)
        {
            Picture = picture;
            Name = name;
            Like = like;
        }
    }
}


