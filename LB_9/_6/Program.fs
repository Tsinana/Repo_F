open System
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
//Главная форма
let mwXaml = "
<Window
xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
    xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
    Title='New Window' Height='221' Width='400'>
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width='156*' />
        <ColumnDefinition Width='163' />
    </Grid.ColumnDefinitions>
    <Button Content='Найти площадь' Grid.Column='1' Height='50' HorizontalAlignment='
Left' Margin='40,10,0,0' Name='button1' VerticalAlignment='Top'
Width='100' IsEnabled='True' />
    <Label Content='а = ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='-200,6,0,0' Name='labelA' VerticalAlignment='Top' />
    <Label Content='b = ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='-200,36,0,0' Name='labelB' VerticalAlignment='Top' />
    <TextBox Height='23' HorizontalAlignment='Left' Margin='50,10,0,0'
Name='textBox1' VerticalAlignment='Top' Width='180' Grid.ColumnSpan='2'
IsEnabled='True' Text = '1'/>
    <TextBox Height='23' HorizontalAlignment='Left' Margin='50,40,0,0'
Name='textBox2' VerticalAlignment='Top' Width='180' Grid.ColumnSpan='2'
IsEnabled='True' Text = '1'/>
    <Button Content='Close' Height='23' HorizontalAlignment='Left' Margin='
12,153,0,0' Name='button2' VerticalAlignment='Top' Width='305'
Grid.ColumnSpan='2' />
    <Label Content=' ' Grid.Column='1' Height='28' HorizontalAlignment='
Left' Margin='-200,90,0,0' Name='label1' VerticalAlignment='Top' />
    </Grid>
</Window>
"
// загрузка разметки XAML
let getWindow(mwXaml) = 
    let xamlObj=XamlReader.Parse(mwXaml)
    xamlObj :?> Window
let win = getWindow(mwXaml)
let nb1 = win.FindName("button1") :?> Button
let nb2 = win.FindName("button2") :?> Button
let nl = win.FindName("label1") :?> Label
let ntb0 = win.FindName("text") :?> TextBox
let ntb1 = win.FindName("textBox1") :?> TextBox
let ntb2 = win.FindName("textBox2") :?> TextBox
//обработка событий
nb1.Click.AddHandler(fun _ _ -> nl.Content<- "S = " + Convert.ToString((ntb1.GetLineText(0) |> Int32.Parse) * (ntb2.GetLineText(0) |> Int32.Parse)))
nb2.Click.AddHandler(fun _ _ -> win.Hide())
// запуск приложения
[<STAThread>] ignore <| (new Application()).Run win 