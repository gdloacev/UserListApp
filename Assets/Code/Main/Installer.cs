using UserListApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UserListApp.InterfaceAdapters.User;
using UserListApp.Views;

namespace UserListApp.Main
{
    internal class Installer: MonoBehaviour
    {
        [SerializeField] private UserListView _userListView;

        private void Awake()
        {
            Debug.Log("Installer");
            UserListViewModel _listModel = new UserListViewModel();
            UserRequester _listRequester = new UserRequester();
            UserListPresenter _listPresenter = new UserListPresenter(_listModel, _listRequester);
            UserController _listController = new UserController(_listModel, _listRequester, "https://randomuser.me/api/?results=50");

            _userListView.Configure(_listModel);

        }
    }
}
