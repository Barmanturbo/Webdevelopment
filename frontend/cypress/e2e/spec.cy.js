describe('Cypress test nummmer 1', () => {
  it('does not much', () => {
    expect(true).to.equal(true)
  })
})

describe('Test account aanmaken: offscreen elements should not exist',()=>{
  it('visits the website', () => {
    cy.visit('http://localhost:3000').get()
    cy.get('ul>li').contains('Mijn account').click()
    cy.get('section>p>a').contains('Klik dan hier om een account aan te maken').click()
    cy.get('.offscreen').should('not.exist');
  })
})