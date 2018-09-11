export class SelectList {
  Id: string;
  DisplayText: string;
  IsSelected: boolean;

  constructor(id: string, displayText: string, isSelected = false) {
    this.Id = id;
    this.DisplayText = displayText;
    this.IsSelected = isSelected;
  }
}
