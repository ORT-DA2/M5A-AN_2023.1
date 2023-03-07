import { AbstractControl } from '@angular/forms';

export function ValidateString(control: AbstractControl): { invalidString: boolean } | null {
  if (control.value?.trim()?.length === 0) {
    return { invalidString: true };
  }
  return null;
}
