import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsersService } from 'src/app/services/users/users.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  form: FormGroup;

  constructor(public formBuilder: FormBuilder, public userService: UsersService, public _toastr: ToastrService) {
    this.form = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
      passwordValidator: ['', Validators.required],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      enrollmentNum: ['', Validators.required],
      enrollmentType: ['', Validators.required],
      phone: ['', Validators.required],
      address: ['', Validators.required],
    });
  }

  ngOnInit() {
  }

  onSubmit() {
    let errorMsg = 'Por favor verifique los datos ingresados.';
    if (this.form.valid) {
      const form = this.form.value;
      if (this.form.value.password === this.form.value.passwordValidator) {
        return this.userService.create({
          email: form.email,
          password: form.password,
          type: 'PROFESSIONAL',
          name: form.name,
          surname: form.surname,
          profId: 1,
          enrollmentNum: form.enrollmentNum,
          enrollmentType: form.enrollmentType,
          phone: form.phone,
          address: form.address
        });
      } else {
        errorMsg = 'Por favor vuelva a ingresar su contraseña. Validación incorrecta.';
      }
    }
    return this._toastr.error(errorMsg);
  }
}
