using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccesful { get; private set; }

        public List<String> Errors { get; set; }

        //Static Factory Method=> statik metodlarla beraber geriye yeni bir nesne dönüyorsanız böyle denir
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccesful=true };
        }
        public static Response<T> Success (int statusCode)
        {
            return new Response<T> { Data=default, StatusCode = statusCode, IsSuccesful=true };
        }
        public static Response<T> Fail (List<String> errors,int statusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = statusCode,
                IsSuccesful = false
            };
        }
        public static Response<T> Fail (string error,int statusCode)
        {
            return new Response<T> { Errors = new List<string>() { error }, StatusCode = statusCode, IsSuccesful = false }; 
        }
    }
}
