using System;
using System.Collections.Generic;
using SorterExpress;

//https://stackoverflow.com/questions/3575311/how-can-i-save-first-frame-of-a-video-as-image

//TODO: Optimise this and make it a singleton?
public class FFMPEG
{
    List<FFMPEGProcess> processes;

    public FFMPEG()
    {
        processes = new List<FFMPEGProcess>();
    }

    /// <summary>
    /// Now you just set StartInfo.Arguments, callback, input, output
    /// </summary>
    private FFMPEGProcess CreateJProcess()
    {
        FFMPEGProcess ffmp = new FFMPEGProcess();

        ffmp.StartInfo.UseShellExecute = false;
        ffmp.StartInfo.RedirectStandardOutput = true;
        ffmp.StartInfo.RedirectStandardError = true;
        ffmp.StartInfo.CreateNoWindow = true;

        ffmp.EnableRaisingEvents = true;

        return ffmp;
    }

    public void GetThumbnail(string input, string output, int size, Action<string> callback)
    {
        FFMPEGProcess ffmpeg = CreateJProcess();

        ffmpeg.StartInfo.FileName = "ffmpeg.exe";
        //ffmpeg.StartInfo.Arguments = "-y -i \"" + directory + "/" + filename + "\" -vframes: 1 -vf scale=" + size + ":" + size + " \"" + output + "\"";
        ffmpeg.StartInfo.Arguments = $"-y -i \"{input}\" -vframes: 1 -vf scale={size}:{size} \"{output}\"";
        ffmpeg.callback = callback;
        ffmpeg.input = input;
        ffmpeg.output = output;
        ffmpeg.Exited += Exited;

        ffmpeg.Start();
        processes.Add(ffmpeg);
    }

    private void Exited(object sender, EventArgs e)
    {
        FFMPEGProcess p = (FFMPEGProcess)sender;

        p.callback.Invoke(p.output);
        processes.Remove(p);
        p.Close();
        p.Dispose();
    }

    public void GetThumbnailWait(string input, string output, int size)
    {
        FFMPEGProcess ffmpeg = CreateJProcess();

        ffmpeg.StartInfo.FileName = "ffmpeg.exe";
        //ffmpeg.StartInfo.Arguments = "-y -i \"" + directory + "/" + filename + "\" -vframes: 1 -vf scale=" + size + ":" + size + " \"" + output + "\"";
        ffmpeg.StartInfo.Arguments = $"-y -i \"{input}\" -vframes: 1 -vf scale={size}:{size} \"{output}\"";
        ffmpeg.input = input;
        ffmpeg.output = output;

        ffmpeg.Start();
        processes.Add(ffmpeg);

        ffmpeg.WaitForExit();

        try {
            processes.Remove(ffmpeg);
        }
        catch { 
            // Sometimes the process isn't found in the list and an exception is thrown, not 
            // much we can do about that, doesnt really matter.
        }

        ffmpeg.Close();
        ffmpeg.Dispose();
    }
}