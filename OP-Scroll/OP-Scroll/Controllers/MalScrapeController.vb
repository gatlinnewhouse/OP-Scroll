Imports System.Net
Imports System.Web.Mvc
Imports HtmlAgilityPack

Namespace Controllers
    Public Class MalScrapeController
        Inherits Controller

        Public Shared Function GetSongs()
            Dim BaseUrl = "https://myanimelist.net/anime/34561"
            Dim client = New WebClient()
            Dim html As String = Nothing
            client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36")

            html = client.DownloadString(BaseUrl)

            If Not html Is Nothing Then
                Dim document = New HtmlDocument()
                document.LoadHtml(html)
                Dim node As HtmlNode = document.DocumentNode





                Dim list = node.SelectNodes("//span[@class='theme-song']")

                'list = node.Descendants("div").Where(Function(x) x.GetAttributeValue("class", "").Equals("theme-songs js-theme-songs opnening")).ToList()

                For Each n In list
                    Console.WriteLine(n.InnerText)
                Next

            End If


        End Function

    End Class
End Namespace