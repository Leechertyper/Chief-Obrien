using System;


namespace Config
{
    [System.Serializable]
    public class roomConfig
    {
        public string room_id;
        public string token;
    }

    public class VoteStatus
    {
        public bool Complete;
        public int Result;
    }

    public class JobID
    {
        public int job_id;
    }
}
