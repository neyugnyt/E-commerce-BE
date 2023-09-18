"use strict";(self.webpackChunkE_commerce_Client=self.webpackChunkE_commerce_Client||[]).push([[713],{9713:(E,u,i)=>{i.r(u),i.d(u,{AccountModule:()=>J});var p=i(6895),s=i(5825),l=i(433),o=i(1571),g=i(5381);function d(n,r){1&n&&(o.TgZ(0,"span",12),o._uU(1," Name is required "),o.qZA())}function c(n,r){1&n&&(o.TgZ(0,"span",12),o._uU(1," Email address is not valid "),o.qZA())}function f(n,r){1&n&&(o.TgZ(0,"span",12),o._uU(1," Password is required "),o.qZA())}let C=(()=>{class n{constructor(t,e,a,m){this.activateRoute=t,this.router=e,this.accountService=a,this.formBuilder=m}ngOnInit(){this.returnUrl=this.activateRoute.snapshot.queryParams.returnUrl||"/shop",this.createLoginForm()}get loginFormControl(){return this.loginForm.controls}createLoginForm(){this.loginForm=this.formBuilder.group({email:["",[l.kI.required,l.kI.email]],password:["",[l.kI.required]]})}onSubmit(){this.accountService.login(this.loginForm.value).subscribe(()=>{this.router.navigateByUrl(this.returnUrl)})}}return n.\u0275fac=function(t){return new(t||n)(o.Y36(s.gz),o.Y36(s.F0),o.Y36(g.B),o.Y36(l.qu))},n.\u0275cmp=o.Xpm({type:n,selectors:[["app-login"]],decls:19,vars:4,consts:[[1,"d-flex","justify-content-center","mt-5"],[1,"col-3"],[3,"formGroup","ngSubmit"],[1,"text-center","mb-4"],[1,"h3","mb-3","font-weight-normal"],[1,"form-label-group"],["formControlName","email","type","email","id","inputEmail","placeholder","Email address",1,"form-control"],["for","inputEmail"],["class","text-danger",4,"ngIf"],["formControlName","password","type","password","id","inputPassword","placeholder","Password",1,"form-control"],["for","inputPassword"],["type","submit",1,"btn","btn-lg","btn-primary","btn-block"],[1,"text-danger"]],template:function(t,e){1&t&&(o.TgZ(0,"div",0)(1,"div",1)(2,"form",2),o.NdJ("ngSubmit",function(){return e.onSubmit()}),o.TgZ(3,"div",3)(4,"h1",4),o._uU(5,"Login"),o.qZA()(),o.TgZ(6,"div",5),o._UZ(7,"input",6),o.TgZ(8,"label",7),o._uU(9,"Email address"),o.qZA(),o.YNc(10,d,2,0,"span",8),o.YNc(11,c,2,0,"span",8),o.qZA(),o.TgZ(12,"div",5),o._UZ(13,"input",9),o.TgZ(14,"label",10),o._uU(15,"Password"),o.qZA(),o.YNc(16,f,2,0,"span",8),o.qZA(),o.TgZ(17,"button",11),o._uU(18,"Sign in"),o.qZA()()()()),2&t&&(o.xp6(2),o.Q6J("formGroup",e.loginForm),o.xp6(8),o.Q6J("ngIf",e.loginFormControl.email.invalid&&e.loginFormControl.email.touched&&(null==e.loginFormControl.email.errors?null:e.loginFormControl.email.errors.required)),o.xp6(1),o.Q6J("ngIf",e.loginFormControl.email.invalid&&e.loginFormControl.email.touched&&(null==e.loginFormControl.email.errors?null:e.loginFormControl.email.errors.email)),o.xp6(5),o.Q6J("ngIf",e.loginFormControl.password.invalid&&e.loginFormControl.password.touched&&(null==e.loginFormControl.password.errors?null:e.loginFormControl.password.errors.required)))},dependencies:[p.O5,l._Y,l.Fj,l.JJ,l.JL,l.sg,l.u],styles:[".form-label-group[_ngcontent-%COMP%]{position:relative;margin-bottom:1rem}.form-label-group[_ngcontent-%COMP%] > input[_ngcontent-%COMP%], .form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{height:3.125rem;padding:.75rem}.form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{position:absolute;top:0;left:0;display:block;width:100%;margin-bottom:0;line-height:1.5;color:#495057;pointer-events:none;cursor:text;border:1px solid transparent;border-radius:.25rem;transition:all .1s ease-in-out}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]::placeholder{color:transparent}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]:not(:placeholder-shown){padding-top:1.25rem;padding-bottom:.25rem}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]:not(:placeholder-shown) ~ label[_ngcontent-%COMP%]{padding-top:.25rem;padding-bottom:.25rem;font-size:12px;color:#777}@supports (-ms-ime-align: auto){.form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{display:none}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]::-ms-input-placeholder{color:#777}}@media all and (-ms-high-contrast: none),(-ms-high-contrast: active){.form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{display:none}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]:-ms-input-placeholder{color:#777}}"]}),n})();var h=i(9751),b=i(4986),P=i(3532);var M=i(9646),Z=i(3900),_=i(4004);function O(n,r){1&n&&(o.TgZ(0,"span",14),o._uU(1," Email address is required "),o.qZA())}function y(n,r){1&n&&(o.TgZ(0,"span",14),o._uU(1," Email address is required "),o.qZA())}function T(n,r){1&n&&(o.TgZ(0,"span",14),o._uU(1," Email address is not valid "),o.qZA())}function A(n,r){1&n&&(o.TgZ(0,"span",14),o._uU(1," Email address is in use "),o.qZA())}function N(n,r){1&n&&(o.TgZ(0,"span",14),o._uU(1," Password is required "),o.qZA())}const w=[{path:"login",component:C},{path:"register",component:(()=>{class n{constructor(t,e,a){this.formBuilder=t,this.accountService=e,this.router=a}ngOnInit(){this.createRegisterForm()}get regFormControl(){return this.registerForm.controls}createRegisterForm(){this.registerForm=this.formBuilder.group({displayName:[null,[l.kI.required]],email:[null,[l.kI.required,l.kI.email],[this.validateEmailNotTaken()]],password:[null,[l.kI.required]]})}onSubmit(){this.accountService.register(this.registerForm.value).subscribe(t=>{this.router.navigateByUrl("/shop")},t=>{console.log(t)})}validateEmailNotTaken(){return t=>function F(n=0,r,t=b.P){let e=-1;return null!=r&&((0,P.K)(r)?t=r:e=r),new h.y(a=>{let m=function v(n){return n instanceof Date&&!isNaN(n)}(n)?+n-t.now():n;m<0&&(m=0);let R=0;return t.schedule(function(){a.closed||(a.next(R++),0<=e?this.schedule(void 0,e):a.complete())},m)})}(300).pipe((0,Z.w)(()=>t.value?this.accountService.checkEmailExist(t.value).pipe((0,_.U)(e=>e?{emailexists:!0}:null)):(0,M.of)(null)))}}return n.\u0275fac=function(t){return new(t||n)(o.Y36(l.qu),o.Y36(g.B),o.Y36(s.F0))},n.\u0275cmp=o.Xpm({type:n,selectors:[["app-register"]],decls:25,vars:7,consts:[[1,"d-flex","justify-content-center","mt-5"],[1,"col-3"],[3,"formGroup","ngSubmit"],[1,"text-center","mb-4"],[1,"h3","mb-3","font-weight-normal"],[1,"form-label-group"],["formControlName","displayName","type","text","id","inputDisplayName","placeholder","Name",1,"form-control"],["for","inputDisplayName"],["class","text-danger",4,"ngIf"],["formControlName","email","type","email","id","inputEmail","placeholder","Email address",1,"form-control"],["for","inputEmail"],["formControlName","password","type","password","id","inputPassword","placeholder","Password",1,"form-control"],["for","inputPassword"],["type","submit",1,"btn","btn-lg","btn-primary","btn-block",3,"disabled"],[1,"text-danger"]],template:function(t,e){1&t&&(o.TgZ(0,"div",0)(1,"div",1)(2,"form",2),o.NdJ("ngSubmit",function(){return e.onSubmit()}),o.TgZ(3,"div",3)(4,"h1",4),o._uU(5,"Register"),o.qZA()(),o.TgZ(6,"div",5),o._UZ(7,"input",6),o.TgZ(8,"label",7),o._uU(9,"Name"),o.qZA(),o.YNc(10,O,2,0,"span",8),o.qZA(),o.TgZ(11,"div",5),o._UZ(12,"input",9),o.TgZ(13,"label",10),o._uU(14,"Email address"),o.qZA(),o.YNc(15,y,2,0,"span",8),o.YNc(16,T,2,0,"span",8),o.YNc(17,A,2,0,"span",8),o.qZA(),o.TgZ(18,"div",5),o._UZ(19,"input",11),o.TgZ(20,"label",12),o._uU(21,"Password"),o.qZA(),o.YNc(22,N,2,0,"span",8),o.qZA(),o.TgZ(23,"button",13),o._uU(24,"Register"),o.qZA()()()()),2&t&&(o.xp6(2),o.Q6J("formGroup",e.registerForm),o.xp6(8),o.Q6J("ngIf",e.regFormControl.displayName.invalid&&e.regFormControl.displayName.touched&&(null==e.regFormControl.displayName.errors?null:e.regFormControl.displayName.errors.required)),o.xp6(5),o.Q6J("ngIf",e.regFormControl.email.invalid&&e.regFormControl.email.touched&&(null==e.regFormControl.email.errors?null:e.regFormControl.email.errors.required)),o.xp6(1),o.Q6J("ngIf",e.regFormControl.email.invalid&&e.regFormControl.email.touched&&(null==e.regFormControl.email.errors?null:e.regFormControl.email.errors.email)),o.xp6(1),o.Q6J("ngIf",null==e.regFormControl.email.errors?null:e.regFormControl.email.errors.emailexists),o.xp6(5),o.Q6J("ngIf",e.regFormControl.password.invalid&&e.regFormControl.password.touched&&(null==e.regFormControl.password.errors?null:e.regFormControl.password.errors.required)),o.xp6(1),o.Q6J("disabled",e.registerForm.invalid))},dependencies:[p.O5,l._Y,l.Fj,l.JJ,l.JL,l.sg,l.u],styles:[".form-label-group[_ngcontent-%COMP%]{position:relative;margin-bottom:1rem}.form-label-group[_ngcontent-%COMP%] > input[_ngcontent-%COMP%], .form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{height:3.125rem;padding:.75rem}.form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{position:absolute;top:0;left:0;display:block;width:100%;margin-bottom:0;line-height:1.5;color:#495057;pointer-events:none;cursor:text;border:1px solid transparent;border-radius:.25rem;transition:all .1s ease-in-out}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]::placeholder{color:transparent}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]:not(:placeholder-shown){padding-top:1.25rem;padding-bottom:.25rem}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]:not(:placeholder-shown) ~ label[_ngcontent-%COMP%]{padding-top:.25rem;padding-bottom:.25rem;font-size:12px;color:#777}@supports (-ms-ime-align: auto){.form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{display:none}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]::-ms-input-placeholder{color:#777}}@media all and (-ms-high-contrast: none),(-ms-high-contrast: active){.form-label-group[_ngcontent-%COMP%] > label[_ngcontent-%COMP%]{display:none}.form-label-group[_ngcontent-%COMP%]   input[_ngcontent-%COMP%]:-ms-input-placeholder{color:#777}}"]}),n})()}];let U=(()=>{class n{}return n.\u0275fac=function(t){return new(t||n)},n.\u0275mod=o.oAB({type:n}),n.\u0275inj=o.cJS({imports:[s.Bz.forChild(w),s.Bz]}),n})();var q=i(9437);let J=(()=>{class n{}return n.\u0275fac=function(t){return new(t||n)},n.\u0275mod=o.oAB({type:n}),n.\u0275inj=o.cJS({imports:[p.ez,U,q.m]}),n})()}}]);