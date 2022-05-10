open System
open System.Drawing
open System.Windows.Forms
open System.IO



let form = new Form()
// 
// labelA
// 
let labelA = new Label()
labelA.AutoSize <- true;
labelA.Location <- new System.Drawing.Point(14, 16);
labelA.Name <- "labelA";
labelA.Size <- new System.Drawing.Size(25, 13);
labelA.TabIndex <- 0;
labelA.Text <- "a = ";
form.Controls.Add(labelA)
// 
// labelB
// 
let labelB = new Label()
labelB.AutoSize <- true;
labelB.Location <- new System.Drawing.Point(14, 42);
labelB.Name <- "labelB";
labelB.Size <- new System.Drawing.Size(25, 13);
labelB.TabIndex <- 1;
labelB.Text <- "b = ";
form.Controls.Add(labelB)
// 
// textBox1
// 
let textBox1 = new TextBox()
textBox1.Location <- new System.Drawing.Point(45, 13);
textBox1.Name <- "textBox1";
textBox1.Size <- new System.Drawing.Size(86, 20);
textBox1.TabIndex <- 2;
textBox1.Text <- "1";
form.Controls.Add(textBox1)
// 
// textBox2
// 
let textBox2 = new TextBox()
textBox2.Location <- new System.Drawing.Point(45, 39);
textBox2.Name <- "textBox2";
textBox2.Size <- new System.Drawing.Size(86, 20);
textBox2.TabIndex <- 3;
textBox2.Text <- "2";
form.Controls.Add(textBox2)
// 
// labelAns
// 
let labelAns = new Label()
labelAns.AutoSize <- true;
labelAns.Location <- new System.Drawing.Point(14, 88);
labelAns.Name <- "labelAns";
labelAns.Size <- new System.Drawing.Size(26, 13);
labelAns.TabIndex <- 5;
labelAns.Text <- "S = ";
form.Controls.Add(labelAns)
// 
// buttonPl
// 
let buttonPl = new Button()
buttonPl.Location <- new System.Drawing.Point(137, 10);
buttonPl.Name <- "buttonPl";
buttonPl.Size <- new System.Drawing.Size(63, 49);
buttonPl.TabIndex <- 4;
buttonPl.Text <- "Найти площадь";
buttonPl.UseVisualStyleBackColor <- true;
form.Controls.Add(buttonPl)
let Ans _ = 
    let strAns = 
        try
            "S = " + Convert.ToString(int(textBox1.Text) * (int(textBox2.Text)))
        with
            | :? System.TypeInitializationException -> 
                printfn "Одно из полей оказалось пустым!"
                "None"
    labelAns.Text <- strAns
buttonPl.Click.Add(Ans)
// 
// Form1
// 
form.AutoScaleDimensions <- new System.Drawing.SizeF(6F, 13F);
form.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize <- new System.Drawing.Size(217, 121);
form.Controls.Add(labelAns);
form.Controls.Add(buttonPl);
form.Controls.Add(textBox2);
form.Controls.Add(textBox1);
form.Controls.Add(labelB);
form.Controls.Add(labelA);
form.Name <- "Form1";
form.Text <- "Form1";
form.ResumeLayout(false);
form.PerformLayout();



// Запускаем форму
do Application.Run(form)

[<EntryPoint>]
let main argv =
    0 // return an integer exit code
