import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../auth.service';


interface LoginForm {
  username: FormControl<string | null>,
  password: FormControl<string | null>,
}


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  form!: FormGroup<LoginForm>;

  constructor(private fb: FormBuilder,private auth: AuthService,private router: Router) { }

  async submitForm(): Promise<void> {
    if (this.form.valid) {
      let username = this.form.get('username')?.value;
      let password = this.form.get('password')?.value;
      if(username && password) {
        let user = await this.auth.login(username,password);
        if(this.auth.lastUrl)
        {
          this.router.navigateByUrl(this.auth.lastUrl);
        }
      }

    } else {
      Object.values(this.form.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }


  ngOnInit(): void {
    console.log('lastUrl: ' + this.auth.lastUrl)
    this.form = new FormGroup<LoginForm>({
      username: new FormControl<string>("", {
        validators: [Validators.required, Validators.minLength(8)]
      }),
      password: new FormControl<string>("", {
        validators: [Validators.required, Validators.minLength(8)]
      })
    });

  }
}
