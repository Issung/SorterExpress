using System;
using System.Drawing;

namespace SorterExpress.Classes
{
    public class FFWorker
    {
        /// <summary>
        /// Now you just set StartInfo.Arguments, callback, input, output
        /// </summary>
        private static FFMPEGProcess CreateFFMPEGProcess()
        {
            FFMPEGProcess process = new FFMPEGProcess();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.CreateNoWindow = true;

            process.EnableRaisingEvents = false;

            return process;
        }

        public static void GetThumbnailWait(string input, string output, int size)
        {
            FFMPEGProcess process = CreateFFMPEGProcess();

            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.Arguments = CreateFfmpegThumbnailArgs(input, output, size);
            process.input = input;
            process.output = output;

            process.Start();

            process.WaitForExit();

            process.Close();
            process.Dispose();
        }

        public static void GetThumbnailAsync(string input, string output, int size, Action<string> callback)
        {
            FFMPEGProcess ffmpeg = CreateFFMPEGProcess();

            ffmpeg.StartInfo.FileName = "ffmpeg.exe";
            ffmpeg.StartInfo.Arguments = CreateFfmpegThumbnailArgs(input, output, size);
            ffmpeg.callback = callback;
            ffmpeg.input = input;
            ffmpeg.output = output;
            
            ffmpeg.Exited += (sender, e) => 
            {
                var process = (FFMPEGProcess)sender;

                if (process.callback != null)
                {
                    callback.Invoke(process.output);
                }

                process.Dispose();
            };

            ffmpeg.Start();
        }

        private static string CreateFfmpegThumbnailArgs(string input, string output, int size)
        {
            // -ss (Screenshot this far into the video (2 seconds ftb).
            // -y (Overwrite output if it already exists).
            // -vframes: 1 (Output 1 frame).
            // -vf (??).
            // -vf scale=w:h.
            // Destination output filepath at end.
            return $"-ss 00:00:02 -y -i \"{input}\" -vframes: 1 -vf scale={size}:{size} \"{output}\"";
        } 

        private static FFProbeProcess CreateFFProbeProcess(bool raiseEvents)
        {
            FFProbeProcess process = new FFProbeProcess();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.EnableRaisingEvents = raiseEvents;

            return process;
        }

        private static void FFProbeExited(object sender, EventArgs e)
        {
            FFProbeProcess p = (FFProbeProcess)sender;

            var nums = p.StandardOutput.ToString().Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);

            if (nums.Length == 2)
                p.callback.Invoke(new Size(int.Parse(nums[0]), int.Parse(nums[1])));
            else
                p.callback.Invoke(new Size(0, 0));

            p.Close();
            p.Dispose();
        }

        public static void GetSizeAsync(string file, Action<Size> callback)
        {
            FFProbeProcess ffprobe = CreateFFProbeProcess(true);

            ffprobe.StartInfo.FileName = "ffprobe.exe";
            ffprobe.StartInfo.Arguments = $"-v error -select_streams v:0 -show_entries stream=width,height -of csv=s=x:p=0 \"{file}\"";
            ffprobe.callback = callback;
            ffprobe.input = file;
            ffprobe.Exited += FFProbeExited;

            ffprobe.Start();
        }

        public static Size GetSizeWait(string filepath)
        {
            FFProbeProcess process = CreateFFProbeProcess(false);

            process.StartInfo.FileName = "ffprobe.exe";
            process.StartInfo.Arguments = $"-v error -select_streams v:0 -show_entries stream=width,height -of csv=s=x:p=0 \"{filepath}\"";
            process.input = filepath;

            process.Start();

            var nums = process.StandardOutput.ReadLine().Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);

            process.StandardOutput.ReadToEnd();     //Fully read both of these buffers to prevent a hand on WaitForExit().
            process.StandardError.ReadToEnd();

            process.WaitForExit();

            process.Close();
            process.Dispose();

            return new Size(int.Parse(nums[0]), int.Parse(nums[1]));
        }
    }
}
