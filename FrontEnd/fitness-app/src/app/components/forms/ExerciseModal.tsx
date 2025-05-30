// 'use client';

// import { useForm } from 'react-hook-form';
// import { CreateExerciseDto } from '../../lib/types';
// import Modal from '../../components/ui/Modal';

// interface ExerciseModalProps {
//   isOpen: boolean;
//   onClose: () => void;
//   onSubmit: (data: CreateExerciseDto) => void;
// }

// export default function ExerciseModal({
//   isOpen,
//   onClose,
//   onSubmit,
// }: ExerciseModalProps) {
//   const {
//     register,
//     handleSubmit,
//     reset,
//     formState: { errors },
//   } = useForm<CreateExerciseDto>();

//   const handleFormSubmit = (data: CreateExerciseDto) => {
//     onSubmit(data);
//     reset();
//   };

//   return (
//     <Modal isOpen={isOpen} onClose={onClose} title="Add New Exercise">
//       <form onSubmit={handleSubmit(handleFormSubmit)} className="space-y-4">
//         <div>
//           <label htmlFor="name" className="block text-sm font-medium text-gray-700">
//             Exercise Name
//           </label>
//           <input
//             id="name"
//             type="text"
//             className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
//             {...register('name', { required: 'Name is required' })}
//           />
//           {errors.name && (
//             <p className="mt-1 text-sm text-red-600">{errors.name.message}</p>
//           )}
//         </div>

//         <div>
//           <label htmlFor="muscleGroup" className="block text-sm font-medium text-gray-700">
//             Muscle Group
//           </label>
//           <input
//             id="muscleGroup"
//             type="text"
//             className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
//             {...register('muscleGroup', { required: 'Muscle group is required' })}
//           />
//           {errors.muscleGroup && (
//             <p className="mt-1 text-sm text-red-600">{errors.muscleGroup.message}</p>
//           )}
//         </div>

//         <div>
//           <label htmlFor="description" className="block text-sm font-medium text-gray-700">
//             Description
//           </label>
//           <textarea
//             id="description"
//             rows={3}
//             className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-indigo-500 focus:ring-indigo-500 sm:text-sm"
//             {...register('description')}
//           />
//         </div>

//         <div className="flex justify-end space-x-3">
//           <button
//             type="button"
//             onClick={onClose}
//             className="px-4 py-2 border border-gray-300 rounded-md shadow-sm text-sm font-medium text-gray-700 bg-white hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo