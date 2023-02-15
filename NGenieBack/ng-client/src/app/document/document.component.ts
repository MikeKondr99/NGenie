import { Component } from '@angular/core';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.css'],
  host: {
    class: 'flex flex-col h-full'
  }
})
export class DocumentComponent {

  editMode: boolean = true;
  markdown: string =
`
# Первичное ознакомление со средствами разработки

Напишите программу, которая принимает на стандартный вход список игр футбольных команд
с результатом матча и выводит на стандартный вывод сводную таблицу результатов всех матчей.
За победу команде начисляется 3 очка, за поражение — 0, за ничью — 1.
Формат ввода следующий:
В первой строке указано целое число **n** — количество завершенных игр.
После этого идет **n** строк, в которых записаны результаты
игры в следующем формате:

![ggg](https://images.unsplash.com/photo-1552728089-57bdde30beb3?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cGFycm90fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60)

[lorem ipsum lolkek](https://developer.mozilla.org/en-US/docs/Web/CSS/::after)

кастомный обработчик для ссылок начинающихся с \`file:\`
[file: презентация](https://developer.mozilla.org/en-US/docs/Web/CSS/::after)

\`\`\` console
Первая_команда;Забито_первой_командой;Вторая_команда;Забито_второй_командой
\`\`\`

none \`let a = 5;\`
\`\`\`rust
let a = 5;
\`\`\`
\`\`\`py
print('lol')
\`\`\`


\`\`\`html
<h2>HTML Buttons</h2>
<p>HTML buttons are defined with the button tag:</p>

<button>Click me</button>
\`\`\`

\`\`\`mermaid
flowchart LR
a --> b
b --> c
c --> a
\`\`\`

I can use katex inline $n^2$ *╰(*°▽°*)╯

or use katex block
$$
f_i(x) = 3x^2 + 4x + 9
$$

$$
матрица  =
\\begin{bmatrix}
   a & b \\\\\\\\
   c & d
\\end{bmatrix}
$$

tag | src | example
-|-|-
меньше равно | \`a \\leqslant b\` | $a \\leqslant b$

Вывод программы необходимо оформить следующим образом:

\`\`\` console
Команда:Всего_игр Побед Ничьих Поражений Всего_очков
\`\`\`

Порядок вывода команд произвольный.

Пример выполнения
\`\`\`console
3
Спартак;9;Зенит;10
Локомотив;12;Зенит;3
Спартак;8;Локомотив;15
> Спартак:2 0 0 2 0
> Зенит:2 1 0 1 3
> Локомотив:2 2 0 0 6
\`\`\`
`

  html: string = ''
  fakeSave: boolean = false;

  toggleEdit() {
    this.editMode = !this.editMode;
  }

  save() {
    this.fakeSave = true;
    setTimeout(() => {
        this.fakeSave = false;
    }, 1000);

  }


}
