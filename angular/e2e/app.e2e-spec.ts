import { ADPortsGroupTemplatePage } from './app.po';

describe('ADPortsGroup App', function() {
  let page: ADPortsGroupTemplatePage;

  beforeEach(() => {
    page = new ADPortsGroupTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
