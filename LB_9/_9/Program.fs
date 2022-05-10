open System
open System.Drawing
open System.Windows.Forms

let form = new Form()
// 
// label1
// 
let label1 = new Label()
label1.AutoSize <- true;
label1.Location <- new System.Drawing.Point(12, 9);
label1.Name <- "label1";
label1.Size <- new System.Drawing.Size(442, 26);
label1.TabIndex <- 0;
label1.Text <- "Приложение выполняет логическую \r\nпроверку над элементами списка и возвращает зна" +
    "чение true, если была найдена \'1\'";
form.Controls.Add(label1)
// 
// label2
// 
let label2 = new Label()
label2.AutoSize <- true;
label2.Location <- new System.Drawing.Point(12, 53);
label2.Name <- "label2";
label2.Size <- new System.Drawing.Size(84, 13);
label2.TabIndex <- 1;
label2.Text <- "Сюда писать ->";
form.Controls.Add(label2)
// 
// textBox
// 
let textBox = new TextBox()
textBox.Location <- new System.Drawing.Point(103, 53);
textBox.Name <- "textBox";
textBox.Size <- new System.Drawing.Size(351, 20);
textBox.TabIndex <- 2;
form.Controls.Add(textBox)
// 
// labelAns
// 
let labelAns = new Label()
labelAns.AutoSize <- true;
labelAns.Location <- new System.Drawing.Point(100, 81);
labelAns.Name <- "labelAns";
labelAns.Size <- new System.Drawing.Size(109, 13);
labelAns.TabIndex <- 4;
// 
// button
// 
let button = new Button()
button.Location <- new System.Drawing.Point(12, 76);
button.Name <- "button";
button.Size <- new System.Drawing.Size(75, 23);
button.TabIndex <- 3;
button.Text <- "Выполнить";
button.UseVisualStyleBackColor <- true;
form.Controls.Add(button)

let func _ =
   let ok = textBox.Text|>String.exists (fun c -> c='1')
   labelAns.Text <- 
   if ok=true then "true"
   else "false"
button.Click.Add(func)
// 
// Form1
// 
form.AutoScaleDimensions <- new System.Drawing.SizeF(6F, 13F);
form.AutoScaleMode <- System.Windows.Forms.AutoScaleMode.Font;
form.ClientSize <- new System.Drawing.Size(469, 111);
form.Controls.Add(labelAns);
form.Controls.Add(button);
form.Controls.Add(textBox);
form.Controls.Add(label2);
form.Controls.Add(label1);
form.Name <- "Form1";
form.Text <- "Form1";
form.ResumeLayout(false);
form.PerformLayout();
// Запускаем форму
do Application.Run(form)