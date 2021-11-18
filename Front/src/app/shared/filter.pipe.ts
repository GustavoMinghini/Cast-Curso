import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filteres'
})
export class FilterPipe implements PipeTransform {

  transform(value: any, filteredString: string){
    if(filteredString == ''){
      return value;
    }
    const users =  [];
    for (const user of value){
      if((!user['cursoNome'].indexOf(filteredString)) || (!user['dtInicio'].indexOf(filteredString)) || (!user['dtTermino'].indexOf(filteredString))) {
        users.push(user);
      }
    }
    return users;
  }

}
