# AfterRun
一定時間後にプロセスを起動したり、プロセス終了時にプロセスを起動する。

# 動作環境
.NET Framework

# 取扱種別
このソフトはフリーウェアです。LICENCEファイルを参照してください。

# インストール
ダウンロードしたファイルは7z形式の自己解凍ファイルです。実行して解凍するか7zなどの解凍ソフトウェアで解凍してください。
インストーラーはありません。

# アンインストール
ファイルを削除してください。アンインストーラーはありません。

# 使用例
## シンプル
以下のコマンドで１分後にメモ帳を起動します。
```
> afterrun -t 1:00 -exe notepad
```

## コマンドライン引数を渡す
```
> afterrun -t 1:00 -exe notepad -arg abc.txt
```

## コマンドライン引数を渡す（URLエンコード）
**-arg** オプションの引数はURLデコードされて解釈されます。そのため **%** を含む場合はURLエンコードしなければなりません。またスペースを含み **"** で囲む場合、 **-** や **/** で始まる場合はなどはURLエンコードする必要があります。
```
> afterrun -t 1:00 -exe winamp -arg %2FPLAY
```
winampには **/PLAY** が渡されます。

```
> afterrun -t 10 -exe C:\Linkout\argCheck\x86\argCheck.exe -arg %2Da+-b+-c+%22x+y+z%22
```
argCheckには **a -b -c "x y z"** が渡されます。 **-** は **%2D** に置き換えなければなりません（通常のURLエンコードでは置き換わりません）。

## プロセスを待ってからプロセスを起動
```
> afterrun -p 7872 -exe notepad
```
プロセスID **7872** のプロセスが終了したらメモ帳を起動します。

# ダウンロード
バイナリーはここから入手できます。
<https://ambiesoft.github.io/webjumper/?target=uploads>

# 寄付
開発の寄付を募集しています。
<https://ambiesoft.github.io/webjumper/?target=donate>

# 作者への連絡先
* 電子メール <ambiesoft.trueff@gmail.com>
* 掲示板 <https://ambiesoft.github.io/webjumper/?target=bbs>
* 開発 <https://github.com/ambiesoft/AfterRun>
