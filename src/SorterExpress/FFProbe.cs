using SorterExpress;
using System;
using System.Collections.Generic;
using System.Drawing;

public class FFProbe
{
    List<FFProbeProcess> processes;

    public FFProbe()
    {
        processes = new List<FFProbeProcess>();
    }

    /// <summary>
    /// Now you just set StartInfo.Arguments, callback, input, output
    /// </summary>
    private FFProbeProcess CreateJProcess()
    {
        FFProbeProcess ffpp = new FFProbeProcess();

        ffpp.StartInfo.UseShellExecute = false;
        ffpp.StartInfo.RedirectStandardOutput = true;
        ffpp.StartInfo.RedirectStandardError = true;
        ffpp.StartInfo.CreateNoWindow = true;

        ffpp.EnableRaisingEvents = true;

        return ffpp;
    }

    public void GetSize(string file, Action<Size> callback)
    {
        FFProbeProcess ffprobe = CreateJProcess();

        ffprobe.StartInfo.FileName = "ffprobe.exe";
        ffprobe.StartInfo.Arguments = $"-v error -select_streams v:0 -show_entries stream=width,height -of csv=s=x:p=0 \"{file}\"";
        ffprobe.callback = callback;
        ffprobe.input = file;
        ffprobe.Exited += Exited;

        ffprobe.Start();
        processes.Add(ffprobe);
    }

    private void Exited(object sender, EventArgs e)
    {
        FFProbeProcess p = (FFProbeProcess)sender;

        var nums = p.StandardOutput.ToString().Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);

        if (nums.Length == 2)
            p.callback.Invoke(new Size(int.Parse(nums[0]), int.Parse(nums[1])));
        else
            p.callback.Invoke(new Size(0, 0));

        processes.Remove(p);
        p.Close();
        p.Dispose();
    }

    public Size GetSizeWait(string file)
    {
        FFProbeProcess ffprobe = CreateJProcess();

        ffprobe.StartInfo.FileName = "ffprobe.exe";
        ffprobe.StartInfo.Arguments = $"-v error -select_streams v:0 -show_entries stream=width,height -of csv=s=x:p=0 \"{file}\"";
        ffprobe.input = file;

        ffprobe.Start();
        //processes.Add(ffprobe);
        ffprobe.WaitForExit();

        var nums = ffprobe.StandardOutput.ReadLine().Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);

        //processes.Remove(ffprobe);
        ffprobe.Close();
        ffprobe.Dispose();

        return new Size(int.Parse(nums[0]), int.Parse(nums[1]));
    }
}