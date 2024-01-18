using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LinkAllConfig;

/// <summary>
/// The form2.
/// </summary>
public partial class Form2 : Form
{
	private readonly Progress<int> progress;

	private CancellationTokenSource? cts;
	private bool isPaused;
	private bool isRunning;

	/// <summary>
	/// Initializes a new instance of the <see cref="Form2"/> class.
	/// </summary>
	public Form2()
	{
		InitializeComponent();
		progress = new Progress<int>(value =>
		{
			if (progressBar.Minimum <= value && progressBar.Maximum >= value)
			{
				progressBar.Value = value;
			}
			else
			{
				Debug.WriteLine("汇报的进度值超出范围：{0}", value);
			}
		});
		btnStartStop.Text = "启动";
		btnStartStop.Enabled = true;
		btnPauseContinue.Enabled = false;
	}

	private async void btnStartStop_ClickAsync(object sender, EventArgs e)
	{
		if (!isRunning)
		{
			// 开始执行任务
			cts = new CancellationTokenSource();
			isPaused = false;
			btnStartStop.Text = "停止";
			btnStartStop.Enabled = true;
			btnPauseContinue.Enabled = true;
			await ExecuteTaskAsync(cts.Token);
		}
		else
		{
			// 停止并退出任务
			if (cts is not null)
			{
				await cts.CancelAsync();
			}
		}
	}

	private async void BtnPauseContinue_ClickAsync(object sender, EventArgs e)
	{
		if (isPaused)
		{
			// 继续任务
			isPaused = false;
			btnPauseContinue.Text = "暂停";
			await ContinueTaskAsync();
		}
		else if (isRunning)
		{
			// 暂停任务
			isPaused = true;
			btnPauseContinue.Text = "继续";
			PauseTask();
		}
	}

	private async Task ExecuteTaskAsync(CancellationToken token)
	{
		isRunning = true;
		try
		{
			await Task.Run(() => DoLongRunningWork(token, progress), token);
		}
		catch (OperationCanceledException)
		{
			// 被取消的任务
		}
		finally
		{
			isRunning = false;
			btnStartStop.Text = "启动";
			btnStartStop.Enabled = true;
			btnPauseContinue.Enabled = false;
		}
	}

	private Task ContinueTaskAsync()
	{
		if (cts is null)
		{
			cts = new CancellationTokenSource();
		}

		// 假设我们有一个方法可以恢复暂停的任务
		return Task.Run(() => ResumeLongRunningWork(), cts.Token);
	}

	private void PauseTask()
	{
		// 假设我们有一个方法可以暂停正在运行的任务
		LongRunningWorkPause();
	}

	private void DoLongRunningWork(CancellationToken token, IProgress<int> progress)
	{
		for (int i = 0; !token.IsCancellationRequested && i < 100; i++)
		{
			// 模拟耗时工作
			Thread.Sleep(300);

			// 更新进度
			progress.Report(i); // 将30秒的工作量调整为100个阶段

			// 检查是否需要暂停或停止
			token.ThrowIfCancellationRequested();
		}
	}

	private void ResumeLongRunningWork()
	{
		/* 实现你的恢复逻辑 */
	}

	private void LongRunningWorkPause()
	{
		/* 实现你的暂停逻辑 */
	}

	private void Progress_ProgressChanged(object sender, int value)
	{
		// 更新进度条控件的值
		Invoke(() => progressBar.Value = value);
	}

	private void Form2_Load(object sender, EventArgs e)
	{
	}
}