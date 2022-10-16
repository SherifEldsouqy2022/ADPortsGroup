import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
  PagedListingComponentBase,
  PagedRequestDto
} from 'shared/paged-listing-component-base';
import { 
  EmployeeDto, EmployeeDtoPagedResultDto, EmployeeServiceProxy
} from '@shared/service-proxies/service-proxies'; 
import { CreateEmployeeComponent } from './create-employee/create-employee.component'; 
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';

class PagedEmployeesRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  animations: [appModuleAnimation()]
})

export class EmployeesComponent extends PagedListingComponentBase<EmployeeDto> {
  employees: EmployeeDto[] = [];
  keyword = '';
  isActive: boolean | null;
  advancedFiltersVisible = false;

  constructor(
    injector: Injector,
    private _employeeService: EmployeeServiceProxy,
    private _modalService: BsModalService
  ) {
    super(injector);
  }

 
  clearFilters(): void {
    this.keyword = '';
    this.isActive = undefined;
    this.getDataPage(1);
  }

  protected list(
    request: PagedEmployeesRequestDto,
    pageNumber: number,
    finishedCallback: Function
  ): void {
    request.keyword = this.keyword;
    request.isActive = this.isActive;

    this._employeeService
      .getAll(
        request.keyword,
        request.isActive,
        request.skipCount,
        request.maxResultCount
      )
      .pipe(
        finalize(() => {
          finishedCallback();
        })
      )
      .subscribe((result: EmployeeDtoPagedResultDto) => { 
        this.employees = result.items;
        this.showPaging(result, pageNumber);
      });
  }

  createEmployee(): void {
    this.showCreateOrEditEmployeeDialog();
  }

  editEmployee(employee: EmployeeDto): void {
    this.showCreateOrEditEmployeeDialog(employee.id);
  } 

  protected delete(employee: EmployeeDto): void {
    abp.message.confirm(
      this.l('employeeDeleteWarningMessage', employee.employeeName),
      undefined,
      (result: boolean) => {
        if (result) {
          this._employeeService.delete(employee.id).subscribe(() => {
            abp.notify.success(this.l('SuccessfullyDeleted'));
            this.refresh();
          });
        }
      }
    );
  } 

  private showCreateOrEditEmployeeDialog(id?: number): void {
    let createOrEditEmployeeDialog: BsModalRef;
    if (!id) {
      createOrEditEmployeeDialog = this._modalService.show(
        CreateEmployeeComponent,
        {
          class: 'modal-lg',
        }
      );
    } else {
      createOrEditEmployeeDialog = this._modalService.show(
        EditEmployeeComponent,
        {
          class: 'modal-lg',
          initialState: {
            id: id,
          },
        }
      );
    }

    createOrEditEmployeeDialog.content.onSave.subscribe(() => {
      this.refresh();
    });
  }
}
