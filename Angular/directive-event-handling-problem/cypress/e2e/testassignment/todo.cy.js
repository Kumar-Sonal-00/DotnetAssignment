describe('land in login page',()=>{

    it ('should load a page and verify the url',()=>{
     cy.visit('/');
   //  cy.url().should('include','todo');
     cy.wait(2000)
    })
 
     it('should display center text',()=>{

   cy.visit("/")
 
   // in header component
   cy.get("h3").contains('Task Tracker app')
 cy.wait(1000)
 
 
     })

      // test for checking empty input and clicking add
  it('should check empty text in input',async () => {
    cy.visit("/")
   
    cy.get("#text-id").click({force:true}).type("")
    cy.get('#addbtn').click()
    cy.get('.empty-p').contains('Todo tasks List is empty!!!')
    cy.wait(2000)
  });
 

    // test for checking after clicking clear
    it('should clear table after clicking clear',async () => {
      cy.visit("/")
      cy.get('#clear-id').click()
      cy.get('.empty-p').contains('Todo tasks List is empty!!!')
      cy.wait(1000)
    
    });

    // test to checking after giving text to input 
    it('should create table after adding todo and checking caption',async () => {
      cy.visit("/")
      cy.get("#text-id").click({force:true}).type("task1")
      cy.get('#addbtn').click()
      cy.get('caption').contains('Todo Tasks')
      cy.wait(1000)
    });

   // test for checking button text of Add button
   it('should check text of Add button',async () => {
    cy.visit("/")
    cy.get('#addbtn').contains('Add')
    cy.wait(1000)
  });

      // test for checking button text of Clear button
      it('should check text of Clear button',async () => {
        cy.visit("/")
        cy.get('##clear-id').contains('Clear')
        cy.wait(1000)
      });


 })