using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;
using Config;
namespace WebHandler
{
    class Request
    {
        string SERVER = "tux6:35000";
        private static readonly HttpClient client = new HttpClient();
        private HttpRequestMessage request;
        private string room;
        roomConfig json;
        VoteStatus vote;
        JobID JOBID;


        public async Task StartVote(){

            HttpResponseMessage response;
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", json.token);
                response = await client.PostAsync(SERVER+"/game/"+json.room_id+"/jobs/", null);
                JOBID = JsonUtility.FromJson<JobID>(response.ToString());
            }
            catch(HttpRequestException e){
            }

        }


        public async Task<int> GetVote(){

            string response;

            try{
               client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", json.token);
               response = await client.GetStringAsync(SERVER+"/game/"+json.room_id+"/jobs/"+JOBID);
               vote = JsonUtility.FromJson<VoteStatus>(response);
            }
            catch(HttpRequestException e){
                System.Random rnd = new System.Random();
                return rnd.Next(1,3);
            }
            if (vote.Complete){
                return vote.Result;
            }
            return -1;
        }



        public async Task GetRoom(){

            string response;

            try{
                response = await client.GetStringAsync(SERVER+"/game");
                json = JsonUtility.FromJson<roomConfig>(response);
            }
            catch(HttpRequestException e){
            }
        }
    }
}
