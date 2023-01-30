import { Component } from '@angular/core';
import { MarkdownService } from '../services/markdown';

@Component({
  providers: [MarkdownService],
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.css']
})
export class DocumentComponent {

  constructor(private md: MarkdownService) {

  }

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

\`\`\` console
Первая_команда;Забито_первой_командой;Вторая_команда;Забито_второй_командой
\`\`\`

Вывод программы необходимо оформить следующим образом:

\`\`\` console
Команда:Всего_игр Побед Ничьих Поражений Всего_очков
\`\`\`

Порядок вывода команд произвольный.

Ввод
\`\`\` console
3
Спартак;9;Зенит;10
Локомотив;12;Зенит;3
Спартак;8;Локомотив;15
\`\`\`

Вывод
\`\`\` console
Спартак:2 0 0 2 0
Зенит:2 1 0 1 3
Локомотив:2 2 0 0 6 
\`\`\`
`

  html: string = ''

  updateArticle() {
    this.html = this.md.render(this.markdown);
  }

  toggleEdit() {
    this.editMode = !this.editMode;
    if(!this.editMode) {
      this.updateArticle();
    }

  }
}
