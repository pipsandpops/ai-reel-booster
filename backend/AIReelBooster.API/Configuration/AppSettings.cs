namespace AIReelBooster.API.Configuration;

public class AppSettings
{
    public FFmpegSettings        FFmpeg               { get; set; } = new();
    public WhisperSettings       Whisper              { get; set; } = new();
    public ClaudeSettings        Claude               { get; set; } = new();
    public StorageSettings       Storage              { get; set; } = new();
    public RazorpaySettings      Razorpay             { get; set; } = new();
    public PredictionSettings    Prediction           { get; set; } = new();
    public FollowerTierSettings  FollowerTiers        { get; set; } = new();
    public InstagramSettings     Instagram            { get; set; } = new();
}

public class RazorpaySettings
{
    public string KeyId { get; set; } = string.Empty;
    public string KeySecret { get; set; } = string.Empty;
}

public class FFmpegSettings
{
    public string BinaryPath { get; set; } = "./ffmpeg-bin";
}

public class WhisperSettings
{
    public string ApiKey { get; set; } = string.Empty;
    public string Endpoint { get; set; } = "https://api.openai.com/v1/audio/transcriptions";
    public string Model { get; set; } = "whisper-1";
}

public class ClaudeSettings
{
    public string ApiKey { get; set; } = string.Empty;
    public string Model { get; set; } = "claude-sonnet-4-6";
    public string Endpoint { get; set; } = "https://api.anthropic.com/v1/messages";
}

public class StorageSettings
{
    public string TempPath { get; set; } = "./temp-jobs";
    public long MaxFileSizeBytes { get; set; } = 500 * 1024 * 1024; // 500 MB
    public int JobTtlMinutes { get; set; } = 60;
}

// ── View Prediction ───────────────────────────────────────────────────────────

/// <summary>
/// Base view/follower multipliers for each viral tier.
/// For a given follower count: views = followers × multiplier × account_scale_factor
/// </summary>
public class PredictionSettings
{
    public TierMultipliers Low    { get; set; } = new(0.05, 0.20);
    public TierMultipliers Medium { get; set; } = new(0.20, 0.80);
    public TierMultipliers High   { get; set; } = new(0.50, 3.00);
}

public record TierMultipliers(double Min, double Max);

/// <summary>
/// Follower tiers shown in scenario table.
/// ScalingFactors[i] dampens the multiplier for larger accounts
/// (bigger accounts have lower engagement-rate percentage).
/// </summary>
public class FollowerTierSettings
{
    public long[]   Tiers          { get; set; } = [1_000, 10_000, 100_000, 500_000, 1_000_000];
    public double[] ScalingFactors { get; set; } = [1.00,   0.65,    0.40,    0.32,     0.28];
}

// ── Instagram ─────────────────────────────────────────────────────────────────

public class InstagramSettings
{
    /// <summary>Meta App ID (from developers.facebook.com)</summary>
    public string AppId           { get; set; } = string.Empty;

    /// <summary>Meta App Secret</summary>
    public string AppSecret       { get; set; } = string.Empty;

    /// <summary>Backend callback URL registered in Meta app settings (e.g. https://your-api.railway.app/api/instagram/callback)</summary>
    public string RedirectUri     { get; set; } = string.Empty;

    /// <summary>Frontend URL to redirect to after OAuth completes (e.g. https://your-app.vercel.app)</summary>
    public string FrontendBaseUrl { get; set; } = "http://localhost:5173";
}
