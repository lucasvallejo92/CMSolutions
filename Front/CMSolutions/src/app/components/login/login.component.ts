import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LOGIN_LANG } from 'src/assets/langs/es/login/login.lang';
import { AuthService } from 'src/app/services/auth/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  lang = LOGIN_LANG;
  form: FormGroup;

  constructor(public formBuilder: FormBuilder, public _authService: AuthService, private _toastr: ToastrService) {
    this._authService.logout();
    this.form = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnInit() {
  }

  onSubmit() {
    if (this.form.valid) {
      this._authService.login(this.form.value);
    } else {
      this._toastr.error('Por favor verifique los datos ingresados.');
    }
  }

}
