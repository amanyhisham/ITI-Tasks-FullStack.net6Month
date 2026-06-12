import { TestBed } from '@angular/core/testing';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting, HttpTestingController } from '@angular/common/http/testing';
import { HeroServiceForLab } from './hero.lab.service';
import { Ihero } from '../../models/ihero';

describe("3-hero service (http) testing:", () => {
  let service: HeroServiceForLab;
  let httpMock: HttpTestingController;
  const heroesUrl = 'http://localhost:3000/heroes';

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        HeroServiceForLab,
        provideHttpClient(),
        provideHttpClientTesting()
      ]
    });

    service = TestBed.inject(HeroServiceForLab);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    // بيتأكد إنه مفيش requests معلقة ماخدتش رد
    httpMock.verify();
  });

  it("getHeroes function: send request and receive response successfully", () => {
    const mockHeroes: Ihero[] = [
      { id: 11, name: 'Mr. Nice', strength: 10 },
      { id: 12, name: 'Narco', strength: 5 }
    ];

    // 1. نستدعي الميثود ونعمل subscribe عشان نتأكد من النتيجة
    service.getHeroes().subscribe(heroes => {
      expect(heroes.length).toBe(2);
      expect(heroes).toEqual(mockHeroes);
    });

    // 2. نتأكد إن request واحد فقط راح على الـ URL ده
    const req = httpMock.expectOne(heroesUrl);

    // 3. نتأكد إن الميثود هي GET
    expect(req.request.method).toBe('GET');

    // 4. نرجع response مزيف عشان الـ subscribe فوق ينفذ
    req.flush(mockHeroes);
  });

  it("updateHero function: send request and receive response successfully", () => {
    const hero: Ihero = { id: 11, name: 'Mr. Nice Updated', strength: 12 };

    service.updateHero(hero).subscribe(response => {
      expect(response).toEqual(hero);
    });

    const req = httpMock.expectOne(heroesUrl);

    expect(req.request.method).toBe('PUT');
    // نتأكد إن الـ body المبعوت هو الـ hero بتاعنا
    expect(req.request.body).toEqual(hero);

    req.flush(hero);
  });
});