Imports System.Net.Http
Imports System.Web.Mvc

Namespace Controllers
    Public Class SpotifyAPIController
        Inherits Controller

        ' GET: SpotifyAPI
        Public Shared Function GetSpotifyClient()
            Dim client As New HttpClient With {
            .BaseAddress = New Uri("https://api.spotify.com/v1/")
            }

            Dim Key As String = "BQCjxIuWWHZmwE_HAV7RwUAl9ST1OroRQaX64V5tTxcbpk7zQS9hinLQLOTRdBYxQ9uB7Mh_bdx-QU3Vsds8K7FBXpwdeueXaKyAsdmLIZ1pFw5XEliTZhrU3FU8NYQEcmG1tw9Q_NnqGyYQyb21CSOXQqDRTxtxz6bSq7HG_kzsqOGRP8cT9ob4O05CI6lEWoYNRw"

            client.DefaultRequestHeaders.Authorization = New Headers.AuthenticationHeaderValue("Bearer", Key)

            Return client

        End Function
    End Class
End Namespace