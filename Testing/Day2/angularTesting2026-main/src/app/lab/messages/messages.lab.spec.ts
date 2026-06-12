 // describe("2-message component testing:", () => {
//     it("expect component template to be empty", () => {
//         //Note: there is @if"messageService.messages.length" in line 1 in template
//     })
//     it("then expect div.msg to have the messages after setting it", () => { })
// })

import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MessagesForLab } from './messages.lab';
import { MessageService } from '../../services/message/message.service';

describe("2-message component testing:", () => {
  let component: MessagesForLab;
  let fixture: ComponentFixture<MessagesForLab>;
  let messageServiceStub: { messages: any[] };

  beforeEach(async () => {
    // Fake service: only has the "messages" array that the template needs
    messageServiceStub = { messages: [] };

    await TestBed.configureTestingModule({
      imports: [MessagesForLab], // standalone component
      providers: [
        { provide: MessageService, useValue: messageServiceStub }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(MessagesForLab);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("expect component template to be empty", () => {
    // messages.length === 0 -> @if is false -> #container should not exist
    const containerEl = fixture.nativeElement.querySelector('#container');
    expect(containerEl).toBeNull();
  });

  it("then expect div.msg to have the messages after setting it", () => {
    // Add messages to the stub
    messageServiceStub.messages = [
      { id: 1, message: 'First message' },
      { id: 2, message: 'Second message' }
    ];

    // Re-render the component after changing the data
    fixture.detectChanges();

    const msgEls: NodeListOf<HTMLElement> =
      fixture.nativeElement.querySelectorAll('div.msg');

    expect(msgEls.length).toBe(2);
    expect(msgEls[0].textContent).toContain('First message');
    expect(msgEls[1].textContent).toContain('Second message');
  });
});