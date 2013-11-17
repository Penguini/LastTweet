Imports TweetSharp
Imports Hammock
Imports Newtonsoft


Public Class Form1
    Dim twitter As New TwitterService("qMzntWVohkQiPLex4Z2Kw", "nRHeE67HghEJT34jolgObvwI6B3J1g2YKTqCPA052o")
    Dim requestToken As OAuthRequestToken

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'twitter.AuthenticateWith("193266604-uG5t0vQzZqeIKAQJ6jR00sIIvupCOohcnt5aTDO3", "cO30qi9MPFJ6JrrQ0lgWpJe8idux8WYO3XpscSZ0pwmhd")

        requestToken = twitter.GetRequestToken
        Dim uri As Uri
        uri = twitter.GetAuthorizationUri(requestToken)

        Process.Start(uri.ToString())

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        Dim verifier As String = TextBox1.Text
        Dim access As New OAuthAccessToken
        access = twitter.GetAccessToken(requestToken, verifier)
        twitter.AuthenticateWith("193266604-uG5t0vQzZqeIKAQJ6jR00sIIvupCOohcnt5aTDO3", "cO30qi9MPFJ6JrrQ0lgWpJe8idux8WYO3XpscSZ0pwmhd")

        Dim request As RestRequest
        request = twitter.PrepareEchoRequest
        request.Path = "uploadAndPost.xml"
        request.AddFile("media", "asdf", "asdf.jpeg", "image/jpeg")
        request.AddField("key", "66ea9abc834b04e712315b40421dc85d")
        request.AddField("message", "Nimpne!!!")

        Dim client As New RestClient() With { _
            .Authority = "http://api.twitpic.com/", _
            .VersionPath = "2" _
        }
        Dim response As RestResponse = client.Request(request)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
