export class UrlConveter {

  static getEmbedUrl(youtubeUrl: string): string | null {
    const Regex = /[?&]v=([^&#]*)/;
    let videoId: string | null = null;
    const match = youtubeUrl.match(Regex);
    videoId = match ? match[1] : null;
    return videoId ? `https://www.youtube.com/embed/${videoId}` : null;
  }

}
