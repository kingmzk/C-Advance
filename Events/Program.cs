
using Events;

namespace Events
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var video = new Video() { Title = "Video 1" };
            var videoEncoder = new VideoEncoder(); //publisher
            var mailService = new MailService(); //subscriber
            var messageService = new MessageService(); //subscriber

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            videoEncoder.Encode(video);



            //Extention  Methods
            string post = "this is supposed to be a very long blog post bluh blah blah blah blah blah ...";
            var shortenedPost = post.Shorten(10);

            Console.WriteLine(shortenedPost);
        }
    }
}
