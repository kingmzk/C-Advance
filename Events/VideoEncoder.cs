﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }


    public class VideoEncoder
    {
        // 1 - define a Delegate
        // 2 - define an event based on that delegate
        // 3 - raise the event

        //public delegate void  VideoEncodedEventHandler(object source, EventArgs args);

      //  public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);
      //  public event VideoEncodedEventHandler VideoEncoded;

        public event EventHandler<VideoEventArgs> VideoEncoded;


        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video");
            Thread.Sleep(3000);
            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            }
        }
    }
}



/*

  public class VideoEncoder
 {
// 1 - define a Delegate
// 2 - define an event based on that delegate
// 3 - raise the event

public delegate void  VideoEncodedEventHandler(object source, EventArgs args);

public event VideoEncodedEventHandler VideoEncoded;


public void Encode(Video video)
{
    Console.WriteLine("Encoding Video");
    Thread.Sleep(3000);
    OnVideoEncoded();
}

protected virtual void OnVideoEncoded()
{
    if (VideoEncoded != null)
    {
        VideoEncoded(this, EventArgs.Empty);
    }
}
*/
