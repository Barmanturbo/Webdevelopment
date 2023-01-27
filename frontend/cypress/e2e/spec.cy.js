describe('Cypress test nummmer 1', () => {
  it('does not much', () => {
    expect(true).to.equal(true)
  })
})
//Cypress bezoekt de website in met een viewport van 1000x660px
describe('Test account aanmaken: offscreen elements should not exist',()=>{
  it('visits the website', () => {
    cy.visit('http://localhost:3000')
    cy.get('.icon').click()
    cy.get('ul>li').contains('Mijn account').click()
    cy.get('section>p>a').contains('Klik dan hier om een account aan te maken').click()
    cy.get('.offscreen').should('not.exist');
  })
})

describe('Test account aanmaken: offscreen elements are on screen if username=wrong',()=>
it('visits create account, fills in wrong username',()=>{
  cy.visit('http://localhost:3000')
  cy.get('.icon').click()
  cy.get('ul>li').contains('Mijn account').click()
  cy.get('section>p>a').contains('Klik dan hier om een account aan te maken').click()
  cy.get('#username').type('a')
  cy.get('.invalid').should('exist')
})
)

describe('Test account aanmaken: offscreen elements are not on screen if username=valid',()=>
it('visits create account, fills in valid username',()=>{
  cy.visit('http://localhost:3000')
  cy.get('.icon').click()
  cy.get('ul>li').contains('Mijn account').click()
  cy.get('section>p>a').contains('Klik dan hier om een account aan te maken').click()
  cy.get('#username').type('aA1_test')
  cy.get('.invalid').should('not.exist')
})
)

describe('Test account aanmaken: offscreen elements are on screen if password=wrong',()=>
it('visits create account, fills in wrong password',()=>{
  cy.visit('http://localhost:3000')
  cy.get('.icon').click()
  cy.get('ul>li').contains('Mijn account').click()
  cy.get('section>p>a').contains('Klik dan hier om een account aan te maken').click()
  cy.get('#password').type('invalidpassword')
  cy.get('.invalid').should('exist')
})
)

describe('Test account aanmaken: offscreen elements are not on screen if password=valid',()=>
it('visits create account, fills in valid password',()=>{
  cy.visit('http://localhost:3000')
  cy.get('.icon').click()
  cy.get('ul>li').contains('Mijn account').click()
  cy.get('section>p>a').contains('Klik dan hier om een account aan te maken').click()
  cy.get('#password').type('ValidPassword1%')
  cy.get('.invalid').should('not.exist')
})
)