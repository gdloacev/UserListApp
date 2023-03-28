using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;
using UserListApp.Domain;
using UserListApp.Utils;

namespace UserListApp.Domain
{
    internal class UserRequester
    {
        public readonly ReactiveCommand<List<User>> SendUserList;

        public UserRequester()
        {
            SendUserList = new ReactiveCommand<List<User>>();
        }

        public async Task GetUsers(string url)
        {
            try
            {
                using HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return;

                var stream = new StreamReader(await response.Content.ReadAsStreamAsync());
                var result = ReadJSON(stream.BaseStream);
                stream.Close();
                SendUserList.Execute(result);
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log(ex.Message);
            }
        }

        private List<User> ReadJSON(Stream stream1)
        {

            StreamReader reader = new StreamReader(stream1);

            try
            {
                string json_str = reader.ReadToEnd();
                UnityEngine.Debug.Log(json_str);
                Root results = JsonUtility.FromJson<Root>(json_str);
                return new List<User>() { new User("", new Name("Mr", "Oscar", "Aceves"),null,"",null,null,null,"","",null,new Picture("","", "https://randomuser.me/api/portraits/thumb/men/35.jpg"), "") };
                //return results!.Results;
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.Log(ex.Message);
                return new List<User>();
            }
            finally
            {
                stream1.Close();
            }
        }
    }
}
