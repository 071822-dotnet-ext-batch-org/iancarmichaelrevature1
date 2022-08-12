/* UPDATE: v0.011:
08.10.2022; So far I've begun to rearrange the structure of the program using Mark's 
            demo code as a template. I've made a RepositoryLayer and BusinessLayer. 
            I know he hasn't yet gotten into using a UI class, but I'm going to 
            try it out by having the UserInterface namespace and EntryPoint.cs class
            handle the user's input. (I'm still very much in the process of refactoring.)
*/
//v0.001:   Initial Birth of the program. 07.27.2022;
/*v0.002:   Revised the blueprint of program to exclude redudant variables.
07.27.2022; Also: added some simple dialogue box functionality to Program.cs
            Also: Experimented with Properties and out parameters, I'll have 
                    a few questions going into class tomorrow~     
*/
/*v0.003:   Lessons learned today about namespaces and classes:
07.28.2022; namespace was previously ExpenseReimbursementSystem. 
            My neural pathways are always under construction.
            Also: I instanciated the Employee class in Program.cs
            Also: I parameterized a constructor for Employee
                 and reorganized my getters and setters.        
*/
//v0.004:   Lots of small refactors in Program.cs. 
/*          Also: I found a way to display trailing zeroes.
07.30.2022;     (This is important since we're dealing
                with currency. Money ain't no game.)
.:Continued later, the same day: 07.30.2022;
            Made the realization that ReimbursementTypes.cs
            isn't even being utilized by the program.            
            Also: I made a directory at the end of the program.
            TODO: Use it, or lose it, enum.        
.:Continued later, the same day: 07.30.2022;
            The noobish else-if monstrosity at the bottom is
            now a proper switch statement.
*/
/*v0.005    Made a new method to call TryParse and recursively loop    
07.31.2022; when the user inputs any letter during Employee ID input
            process. Inadvertantly created a bug(?) where the user must
            input a value again to proceed with the program, but I've 
            accounted for it by using prompts to the user. Almost seems 
            like an intentional layer of validation for user input.
            Definitely keeping it for now.
            TODO: Figure out how to refactor this code to bring it
                more in line with the principles of OOP.
*/
/*v0.01:    I've finally hatched a plan to refactor my project one. Lots of work
08.07.2022; remains, but I'm confident I can get it done. Having started with my 
            hideous program.cs file, I've started to store the existing functionality 
            inside a method in another class. Separation of concerns has taken me way 
            too long to implement, but in fairness, with QC anxieties always mounting, 
            it's not entirely unreasonable to just be getting started. I feel lucky 
            to have gotten as far as I did with p1 before having to study nearly 24/7.
*/

using PresentationLayer;


EntryPoint begin = new EntryPoint();
begin.EntryPointMain();