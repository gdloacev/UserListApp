using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UserListApp.InterfaceAdapters.User;


namespace UserListApp.Views
{
	public class UserListView : MonoBehaviour
	{
		[SerializeField] private Button _loginButton;
		[SerializeField] private TextMeshProUGUI _userName;
		[SerializeField] private RawImage _userPhoto;

		private UserListViewModel _model;
        private Texture2D _texture;

		public void Configure(UserListViewModel model)
		{
			try
			{
                Debug.Log("View - Configure");
                _model = model;
				_loginButton.onClick.AddListener(() => {
                    _model.ShowUserList.Execute();
                    _userName.SetText("Cargando...");
                });
                _model.UserListUpdated.Subscribe(GetUserList);
                _texture = new Texture2D(1, 1, TextureFormat.ARGB32, false);
            }
			catch (System.Exception ex)
			{
				Debug.Log(ex.Message);
			}
		}

		private void GetUserList(Unit _) {
            Debug.Log("View - GetUserList");
            Debug.Log(_model.UserList.Value.Count.ToString());
            
            _model.UserList.Value.ForEach(user => {
                _userName.SetText(user.Name.ToString());
                _userPhoto.StartCoroutine(GetTexture(user.Picture));
            });
        }

        IEnumerator GetTexture(string url)
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
            yield return www.SendWebRequest();

            _texture = DownloadHandlerTexture.GetContent(www);
            _userPhoto.texture = _texture;
        }
    }

}
