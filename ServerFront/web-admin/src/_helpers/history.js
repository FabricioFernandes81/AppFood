/* let navigateRef = null;

export const history = {
   
   navigate: (...args) => navigateRef?.(...args),
  setNavigate: (nav) => { navigateRef = nav; },
}; */

export const history = {
    navigate: null,
    location: null
};