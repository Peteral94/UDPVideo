﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace UDPVideo.Models
{
    class Video
    {
        public DateTime date {get; set; }
        public string pictureid { get; set; }
        public string piMessage { get; set; }
        
        



        public override string ToString()
        {
            return "Dato og tid: " + date + piMessage + ": message Recieved";
        }

    }
}
