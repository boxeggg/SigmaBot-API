﻿using Azure.Core;
using RequestQueue.Models;
using System.Collections;
using System.Collections.Generic;

namespace RequestQueue.Services
{
    public interface IRequestService
    {
        public Queue<RequestModel> GetAllRequest();
        public RequestModel GetLastRequest();
        public bool AddRequest(RequestModel request);
        public bool RemoveRequest();
        public int RequestsCount();
    }
    public class RequestService : IRequestService
    {
        private  Queue<RequestModel>  SongQueue = new Queue<RequestModel>();
        public RequestModel test = new RequestModel();
        
        public Queue<RequestModel> GetAllRequest()
        {

            return new Queue<RequestModel>(SongQueue);
        }
        public RequestModel GetLastRequest()
        {
            try
            {
                return SongQueue.Peek();
            }
            catch(Exception e) 
            {
                return null;
            }
        }
        public bool AddRequest(RequestModel request)
        {
            try
            {
                SongQueue.Enqueue(request);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RemoveRequest() {
            try
            {
                SongQueue.Dequeue();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public int RequestsCount() 
        { 
            return SongQueue.Count();
        }
        
    }
}
