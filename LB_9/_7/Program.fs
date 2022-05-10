
open System.Drawing
open System
open System.Windows.Forms



let form = new Form()
// 
// label1
// 
let label1 = new Label()
label1.AutoSize <- true;
label1.Location <- new System.Drawing.Point(14, 16);
label1.Name <- "label1";
label1.Size <- new System.Drawing.Size(45, 13);
label1.TabIndex <- 0;
label1.Text <- "log(a) b ";
form.Controls.Add(label1)
// 
// labelB
// 
let labelB = new Label()
labelB.AutoSize <- true;
labelB.Location <- new System.Drawing.Point(99, 42);
labelB.Name <- "labelB";
labelB.Size <- new System.Drawing.Size(25, 13);
labelB.TabIndex <- 1;
labelB.Text <- "b = ";
form.Controls.Add(labelB)
// 
// textBox1
// 
let textBox1 = new TextBox()
textBox1.Location <- new System.Drawing.Point(45, 39);
textBox1.Name <- "textBox1";
textBox1.Size <- new System.Drawing.Size(44, 20);
textBox1.TabIndex <- 2;
textBox1.Text <- "0";
form.Controls.Add(textBox1)
// 
// textBox2
// 
let textBox2 = new TextBox()
textBox2.Location <- new System.Drawing.Point(130, 39);
textBox2.Name <- "textBox2";
textBox2.Size <- new System.Drawing.Size(44, 20);
textBox2.TabIndex <- 3;
textBox2.Text <- "0";
form.Controls.Add(textBox2)
// 
// labelA
// 
let labelA = new Label()
labelA.AutoSize <- true;
labelA.Location <- new System.Drawing.Point(14, 42);
labelA.Name <- "labelA";
labelA.Size <- new System.Drawing.Size(25, 13);
labelA.TabIndex <- 5;
labelA.Text <- "a = ";
form.Controls.Add(labelA)
// 
// labelAns
// 
let labelAns = new Label()
labelAns.AutoSize <- true;
labelAns.Location <- new System.Drawing.Point(219, 43);
labelAns.Name <- "labelAns";
labelAns.Size <- new System.Drawing.Size(0, 13);
labelAns.TabIndex <- 6;
form.Controls.Add(labelAns)
// 
// buttonPl
// 
let buttonPl = new Button()
buttonPl.Location <- new System.Drawing.Point(190, 39);
buttonPl.Name <- "buttonPl";
buttonPl.Size <- new System.Drawing.Size(23, 20);
buttonPl.TabIndex <- 4;
buttonPl.Text <- "=";
buttonPl.UseVisualStyleBackColor <- true;
form.Controls.Add(buttonPl)
let Ans _ = 
    let a = textBox2.Text |> Double.Parse
    let b = textBox1.Text |> Double.Parse
    let str = Convert.ToString(Math.Log(a,b))
    labelAns.Text <- str
buttonPl.Click.Add(Ans)
// 
// Form1
// 

form.AutoScaleDimensions <- new System.Drawing.SizeF(6F, 13F);
form.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize <- new System.Drawing.Size(296, 85);
form.Controls.Add(labelAns);
form.Controls.Add(labelA);
form.Controls.Add(buttonPl);
form.Controls.Add(textBox2);
form.Controls.Add(textBox1);
form.Controls.Add(labelB);
form.Controls.Add(label1);
form.Name <- "Form1";
form.Text <- "Form1";
form.ResumeLayout(false);
form.PerformLayout();

// Запускаем форму
do Application.Run(form)

[<EntryPoint>]
let main argv =
    0