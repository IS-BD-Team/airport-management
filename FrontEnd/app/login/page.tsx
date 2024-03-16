'use client'
import { useRouter } from 'next/navigation';
import { FormEvent } from 'react';
import {serialize} from 'cookie';

const Login: React.FC = () => {  
  const router = useRouter();

  const handleSubmit = async(event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    // Add logic to process login here
    router.push('../dashboard')
    const formData = new FormData(event.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');
        
    // const request = await fetch('/api/login', {
    //   method: 'POST',
    //   body: JSON.stringify({ email, password }),
    //   headers: { 'Content-Type': 'application/json' },
    // });

    // if (request.ok) {
    //   const Coockies = request.headers.get('Set-Cookie');
    //   console.log(Coockies);
    //   const data = await request.json();
    //   const token = data['token'];
    //   const serialized = serialize('userToken',token,
    //   {
    //     httpOnly: true,
    //     path: '/',
    //   });
    //   request.headers.append('Set-Cookie', serialized);
    // } else {
    //   console.error('Error al loguearse');
    // }    
    
    router.push('../dashboard/Home');

  };

  return (
    <form onSubmit={handleSubmit} className="flex flex-col p-4 max-w-sm mx-auto mt-10 space-y-4 bg-white shadow-md rounded-lg">
      <div>
        <label htmlFor="eserEmail" className="block text-sm font-medium text-gray-700">Username</label>
        <input
          id="userEmail"
          type="email"
          className="mt-1 block w-full px-3 py-2 bg-gray-50 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
        />
      </div>
      <div>
        <label htmlFor="password" className="block text-sm font-medium text-gray-700">Password</label>
        <input
          id="password"
          type="password"
          className="mt-1 block w-full px-3 py-2 bg-gray-50 border border-gray-300 rounded-md shadow-sm placeholder-gray-400 focus:outline-none focus:ring-indigo-500 focus:border-indigo-500"
        />
      </div>
      <button type="submit" className="px-4 py-2 bg-indigo-600 text-white font-semibold rounded-md hover:bg-indigo-700 focus:outline-none focus:bg-indigo-700">Log in</button>
    </form>
  );
};

export default Login;
