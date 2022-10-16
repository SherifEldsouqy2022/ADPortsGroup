import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  EmployeeServiceProxy,
  CreateEmployeeDto, 
} from '@shared/service-proxies/service-proxies';
import { AbpValidationError } from '@shared/components/validation/abp-validation.api';

@Component({
  templateUrl: './create-employee.component.html'
})
export class CreateEmployeeComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  employee = new CreateEmployeeDto();  

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _employeeService: EmployeeServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {  
  }   

  save(): void {
    this.saving = true; 
    this._employeeService.create(this.employee).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
