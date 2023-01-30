import md from 'markdown-it';

export class MarkdownService {
    md = md();


    render(text: string) {
        return this.md.render(text);
    }

}

