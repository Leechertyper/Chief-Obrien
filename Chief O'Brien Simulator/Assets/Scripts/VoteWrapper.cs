using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UnityEngine;
using Config;
namespace WebHandler
{
    public class Request
    {
        private static readonly string SERVER = "http://tux6:35000";
        private static readonly HttpClient client = new HttpClient();
        private HttpRequestMessage request;
        public roomConfig json;
        private VoteStatus vote;
        private JobID JOBID;


        public async Task StartVote(){

            HttpResponseMessage response;
            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", json.token);
                response = await client.PostAsync(SERVER+"/game/"+json.room_id+"/jobs", null);
                Debug.Log(await response.Content.ReadAsStringAsync());
                JOBID = JsonUtility.FromJson<JobID>(await response.Content.ReadAsStringAsync());
            }
            catch(HttpRequestException e){
            }

        }


        public async Task<int> GetVote(){

            string response;

            try{
               client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", json.token);
               response = await client.GetStringAsync(SERVER+"/game/"+json.room_id+"/jobs/"+JOBID.job_id);
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

            HttpResponseMessage response;

            try{
                response = await client.PostAsync(SERVER+"/game", null);
                Debug.Log(await response.Content.ReadAsStringAsync());
                json = JsonUtility.FromJson<roomConfig>(await response.Content.ReadAsStringAsync());
            }
            catch(HttpRequestException e){
            }
        }

        public async Task KillRoom(){
            HttpResponseMessage response;

            try{
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", json.token);
                response = await client.DeleteAsync(SERVER+"/game/"+json.room_id);
                Debug.Log(await response.Content.ReadAsStringAsync());
            }
            catch(HttpRequestException e){
            }
        }
    }
}
